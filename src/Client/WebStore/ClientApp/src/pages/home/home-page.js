import React from 'react';
import Banners from '../../components/common/Banners';
import { makeStyles } from '@material-ui/core/styles';
import { Grid, Paper } from '@material-ui/core';

import clothing from '../../assets/img_clothing.jpg';
import "./home-page-style.css";

const useStyles = makeStyles((theme) => ({
    root: {
        flexGrow: 1,
    },
    paper: {
        height: 380,
        width: 260,
        padding: theme.spacing(3),
        marginLeft: theme.spacing(3),
        marginBottom: theme.spacing(5),
        position: 'relative',
        background: 'white',
        direction: 'column',
        textAlign: 'center',
        alignItems: 'center',
        justify: 'center',
        fontWeight:500,
    },
}));

function HomePage() {
    const classes = useStyles();

    return (

        <div className="home">
            <Banners />
            <Grid container direction="row" justify="center" alignItems="center" xs={12} spacing={3} className={classes.root}>
                <Grid key="clothing" item xs={3}>
                    <Paper className={classes.paper} square='true'>
                        <p>Clothing</p>
                        <img src={clothing} alt="Logo" />
                    </Paper>
                    </Grid>
                {[0, 1, 2, 3, 4].map((value) => (
                    <Grid key={value} item xs={3}>
                        <Paper className={classes.paper} square='true'>{value}</Paper>
                        </Grid>
                    ))}
                </Grid>
        </div>
    );
}
export default HomePage;
