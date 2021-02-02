import axios from 'axios'; 

// window origin - base url
const origin = window.location.origin;
axios.defaults.baseURL = origin;


const config = {
  defaultPaletteColors: {
    primary: {
      light: '#484848',
      main: '#212121',
      dark: '#000000',
    },
    secondary: {
      light: '#ffff6e',
      main: '#009688',
      dark: '#009692',
    },
  },
}

export default config;
