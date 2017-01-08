import {combineReducers} from 'redux';
import customers from './customer';
import app from './app';

const reducerCollection = {
    customers,
    app
};


 
const cmApp = combineReducers(
    reducerCollection
  );


export default cmApp;