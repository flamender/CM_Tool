
import * as actionTypeConst from '../constants/actionTypeConst';

const app = (state = {}, action) => {
    switch (action.type) {
        case  actionTypeConst.INC_PAGE_ID:
        let anObj = Object.assign({}, state, { selectedPage: action.selectedKey});            
            return anObj
        default:
            return state
    }
};


export default app;
