import { createStore, applyMiddleware, compose } from 'redux';
import persistState from 'redux-localstorage';
import thunk from 'redux-thunk';
import rootReducer, { reducerCollection } from '../reducers';


export const configureStore = (initialState) => {
    // Note: only Redux >= 3.1.0 supports passing enhancer as third argument.
    // See https://github.com/rackt/redux/releases/tag/v3.1.0
    const persistedReducers = Object.keys(reducerCollection);
    persistedReducers.splice(persistedReducers.indexOf('transientUIState'), 1);

    let finalCreateStore = compose(
      // Required! Enable Redux DevTools with the monitors you chose
      applyMiddleware(thunk),

      persistState(
        persistedReducers,
        { key: 'rigilog' }
      )
    );

    if (process.env.NODE_ENV !== 'production') {
        finalCreateStore = compose(
          finalCreateStore,
          DevTools.instrument()
        );
    }

    finalCreateStore = compose(finalCreateStore)(createStore);

    const store = finalCreateStore(rootReducer, initialState);

    // FIXME: Update localstorage to support callbacks
//    RequestHelper.accessToken = store.getState().user.accessToken;

  //  if (process.env.NODE_ENV !== 'production') {
    //    window.store = store;
   // }

    return store;
};
