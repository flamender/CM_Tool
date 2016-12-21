import fetch from 'isomorphic-fetch'
const apiUrl = __API_URL__;
const jenkinsApiUrl = apiUrl + '/jenkins';


export function getJenkins() {
    return (dispatch, getState) => {
        dispatch(getTodosRequest());
        fetch(todoApiUrl, {
            headers: {
                'Accept': 'application/json'
            }
        })
        .then(checkStatus)
        .then(parseJSON)
        .then(data => {
            dispatch(getTodosSuccess(data));
        })
        .catch(handleApiError);
    };
}