import React from 'react';
import ReactDOM from 'react-dom';
import { createStore } from 'redux'
import { Provider } from 'react-redux';
import $ from 'jquery'
import App from './containers/App';
import reducer from './reducers';


const store = createStore(reducer)

  
ReactDOM.render(    
    <Provider store={store}>     
    <App />
    </Provider>,
document.getElementById('react-container')
);


store.dispatch({
    type: 'INC_PAGE_ID',
    selectedKey:  2    
})

store.dispatch({
    type: 'INC_PAGE_ID',
    selectedKey:  3    
})

store.dispatch({
    type: 'GET_All_REQUEST',   
})




console.log( store.getState());
