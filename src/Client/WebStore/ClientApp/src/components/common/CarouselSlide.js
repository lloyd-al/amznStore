import React from 'react';
import { Card, CardMedia, makeStyles } from '@material-ui/core';

export default function CarouselSlide(props) {
    const { banner, title } = props.content;

    const useStyles = makeStyles(() => ({
        card: {
            borderRadius: '0px 0px 0px 0px',
            display: 'flex',
            justifyContent: 'center',
            width: '100%',
            zIndex: '-1',
            marginBottom: '-150px',
            maskImage: 'linear-gradient(to bottom, rgba(0, 0, 0, 1), rgba(0, 0, 0, 0))'
        }
    }));

    const classes = useStyles();

    return (
        <Card className={classes.card}>
            <CardMedia>
                <img src={banner} alt={title} />
            </CardMedia>
        </Card>
    );
}