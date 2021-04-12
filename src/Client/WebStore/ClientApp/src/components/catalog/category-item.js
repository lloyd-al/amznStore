import React from 'react';
import { withRouter, useHistory } from 'react-router-dom';
import { makeStyles } from '@material-ui/core/styles';
import { Paper } from '@material-ui/core';

import './category-item-style.css';

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
        fontWeight: 500,
    },
    image: {
        height: 300,
        width: 200,
        cursor: 'pointer',
    }
}));

const CategoryItem = ({ id, categoryName, imageUrl }) => {
    const classes = useStyles();
    let history = useHistory();

    return (
        <Paper className={classes.paper} square={true}>
            <h6>{categoryName.toUpperCase()}</h6>
            <div>
                {
                    (id === 'all')
                        ? 
                        
                        <div to={`/shop`} onClick={() => history.push({ pathname: `/shop`, state: { id, categoryName } })}>
                            <img src={imageUrl} alt={categoryName.toUpperCase()} className={classes.image} />
                        </div>
                        :
                        <div onClick={() => history.push({ pathname: `/shop/${categoryName}`, state: { id, categoryName } })}>
                            <img src={imageUrl} alt={categoryName.toUpperCase()} className={classes.image} />
                        </div>
                }
            </div>
        </Paper>
    );
}

export default withRouter(CategoryItem);