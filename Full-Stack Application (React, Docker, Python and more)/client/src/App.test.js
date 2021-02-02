// jest-dom adds custom jest matchers for asserting on DOM nodes.
// allows you to do things like:
// expect(element).toHaveTextContent(/react/i)
// learn more: https://github.com/testing-library/jest-dom
import '@testing-library/jest-dom/extend-expect';
import { App } from './App';
import ReactDOM from 'react-dom';
import { Provider } from 'react-redux';
import { createStore } from 'redux';
import rootReducer from './redux/reducers';
const store = createStore(rootReducer);


it('renders without crashing', () => {
    const div = document.createElement('div');
    ReactDOM.render(
    <Provider store={store}>
        <App />
    </Provider>
    , div);
  });
