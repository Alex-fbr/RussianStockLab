import risReducer from "./risReducer";
import { combineReducers } from 'redux';

const reducer = combineReducers({
  risReducer: risReducer,
});

export default reducer;
