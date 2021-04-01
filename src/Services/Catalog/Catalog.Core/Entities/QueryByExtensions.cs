using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace amznStore.Services.Catalog.Core.Entities
{
    public static class QueryByExtensions
    {
        public static async Task<(IEnumerable<TDocument> data, long totalRecords, int totalPages)> AggregateByPage<TDocument>(
            this IMongoCollection<TDocument> collection,
            FilterDefinition<TDocument> filterDefinition,
            SortDefinition<TDocument> sortDefinition,
            int page,
            int pageSize)
        {
            var countFacet = AggregateFacet.Create("count",
                PipelineDefinition<TDocument, AggregateCountResult>.Create(new[] {
                    PipelineStageDefinitionBuilder.Count<TDocument>()
                }));

            var dataFacet = AggregateFacet.Create("data",
                PipelineDefinition<TDocument, TDocument>.Create(new[] {
                    PipelineStageDefinitionBuilder.Sort(sortDefinition),
                    PipelineStageDefinitionBuilder.Skip<TDocument>((page - 1) * pageSize),
                    PipelineStageDefinitionBuilder.Limit<TDocument>(pageSize),
                }));


            var aggregation = await collection.Aggregate()
                .Match(filterDefinition)
                .Facet(countFacet, dataFacet)
                .ToListAsync();

            var count = aggregation.FirstOrDefault()
                .Facets.FirstOrDefault(x => x.Name == "count")
                .Output<AggregateCountResult>()
                .First()
                .Count;

            var totalPages = (int)Math.Ceiling((double)count / pageSize);

            var data = aggregation.FirstOrDefault()
                .Facets.FirstOrDefault(x => x.Name == "data")
                .Output<TDocument>();

            return (data, count, totalPages);
        }
    }
}
