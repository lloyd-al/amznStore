import React, { useEffect } from 'react';
import { connect } from 'react-redux';
import { compose } from 'redux';
import { createStructuredSelector } from 'reselect';
import { makeStyles } from '@material-ui/core/styles';
import { Grid } from '@material-ui/core';

import { selectCategoryCollection, selectCategoryLoading, selectCategoryError } from '../../redux/category/categorySelectors';
import { getAllCategories } from '../../redux/category/categoryActions'; 
import CategoryItem from './category-item';

import clothing from '../../assets/img_clothing.jpg';

const useStyles = makeStyles((theme) => ({
    root: {
        flexGrow: 1,
    },
}));

const Categories = (props) => {
    const classes = useStyles();
    const { categories, loading, error, getAllCategories } = props;

    useEffect(() => {
        getAllCategories()
    }, [getAllCategories])  


    return (
        <div>
            { loading ? (
                <p><em>Loading...</em></p>
            ) : error ? (
                    <p><em>Oops... Something Went Wrong</em></p>
                ) : (
                        <Grid container item direction="row" justify="center" alignItems="center" xs={12} spacing={3} className={classes.root}>
                            <Grid item key="AllClothing" xs={3}>
                                <CategoryItem id="0" categoryName="" imageUrl={clothing} />
                            </Grid>

                            {categories && categories.map(({ id, ...otherSectionProps }) => (
                                <Grid item key={id} xs={3}>
                                    <CategoryItem id={id} {...otherSectionProps} />
                                </Grid>
                            ))}
                        </Grid>
                    )
            }
        </div>
    );  
}

//const mapStateToProps = state => {
//    return {
//        categories: state.categories
//    }
//}

const mapStateToProps = createStructuredSelector({
    categories: selectCategoryCollection(),
    loading: selectCategoryLoading(),
    error: selectCategoryError()

})

const mapDispatchToProps = dispatch => {
    return {
        getAllCategories: () => dispatch(getAllCategories())
    }
}

const withConnect = connect(mapStateToProps, mapDispatchToProps);

export default compose(withConnect)(Categories) 
