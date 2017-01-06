import fetchCustomer from '../actions/customer';

const GET_All_REQUEST = 'GET_All_REQUEST'; 
const SELECT_REQUEST  =  'SELECT_REQUEST';







const customers = (state = [], action) => {
    switch (action.type) {
        case  GET_All_REQUEST:            
            return  [
                     ...state,
                     {name : 'Migros' , id : 1},
                     {name : 'DEZA', id:2}
                   ]
        case SELECT_REQUEST:

        default:
            return state
    }
};


export default customers