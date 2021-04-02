import axios from 'axios';

export const amznApiInstance = axios.create({
    baseURL: 'https://localhost:44302/webgateway',
    headers: {
        'Accept': 'application/json',
        'Content-Type': 'text/json',
        'Access-Control-Allow-Origin': '*',
        'Access-Control-Allow-Headers': 'Origin, Content-Type, Accept',
        'Access-Control-Allow-Methods': 'POST,GET,OPTIONS,PUT,DELETE'
    }
});

