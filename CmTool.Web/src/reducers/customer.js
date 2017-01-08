import fetchCustomer from '../actions/customer';
import * as actionTypeConst from '../constants/actionTypeConst';



const customers = (state = [], action) => {
    switch (action.type) {
        case  actionTypeConst.GET_All_REQUEST:            
            return  [
                     ...state,
                     {name : 'Migros' , id : 1},
                     {name : 'DEZA', id:2}
                   ]
        case actionTypeConst.SELECT_REQUEST:
           return state
        default:
            return state
    }
};


export default customers