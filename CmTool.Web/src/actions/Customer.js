import fetch from 'isomorphic-fetch'
import * as types from '../constants/ActionTypes';


export const FETCHING_CUSTOMER = 'FETCHING_CUSTOMERS';



const apiUrl = __API_URL__;
const jenkinsApiUrl = apiUrl + '/jenkins';


const getCustomerRequest = ()=> {{type: types.GET_All_REQUEST }};

const parseJSON  = (response) => {
    return response.json();
};


const checkStatus = (response)  => {
    if (response.status >= 200 && response.status < 300) {
        return response
    } else {
        var error = new Error(response.statusText)
        error.response = response
        throw error
    }
};


const  getCustomerSuccess = (customers) => {
    return {
        type: types.GET_SUCCESS,
        customers: customers
    };
};



function handleApiError(error) {
    console.log('request failed', error)
}


export default function getCustomer() {
    return (dispatch) => {               
        fetch(jenkinsApiUrl, {
            headers: {
                'Accept': 'application/json'
            }
        })
        .then(checkStatus)
        .then(parseJSON)
        .then(data => {
            dispatch(getCustomerSuccess(data));
        })
        .catch(handleApiError);        
    };
}

