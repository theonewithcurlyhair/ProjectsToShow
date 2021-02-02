import { combineReducers } from 'redux';
import leads from './leads';
import {reducer as notifications } from 'react-notification-system-redux';

const rootReducer = combineReducers({leads, notifications});

export default rootReducer;