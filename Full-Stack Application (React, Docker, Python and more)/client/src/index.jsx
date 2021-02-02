import React from 'react';
import ReactDOM from 'react-dom';
import App from './App';
import { Provider } from 'react-redux';
import store from './redux/store';
import * as serviceWorker from './serviceWorker';

const rootElement = document.getElementById("root");

ReactDOM.render(
	<Provider store={store}>
		<App />
	</Provider>,
	 rootElement);

serviceWorker.unregister();
