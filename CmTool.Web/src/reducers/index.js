import {combineReducers} from 'redux';
import customers from './customer';


const reducerCollection = {
    customers
};


 
const cmApp = combineReducers(
    reducerCollection
  );


export default cmApp;