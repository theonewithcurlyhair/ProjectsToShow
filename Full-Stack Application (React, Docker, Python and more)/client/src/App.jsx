import React from 'react';
import CssBaseline from '@material-ui/core/CssBaseline';
import Grid from '@material-ui/core/Grid';
import Header from './components/Header/Header';
import Home from './containers/Home';
import { MuiThemeProvider, createMuiTheme, makeStyles } from '@material-ui/core/styles';
import config from './config';
import Notifications from 'react-notification-system-redux';
import { connect } from 'react-redux';
import { changeDocumentTitle } from './util/methods';

const useStyles = makeStyles((theme) => ({
  root: {
    width: "auto",
    marginTop: theme.spacing(10),
    marginLeft: theme.spacing(3),
    marginRight: theme.spacing(3),
    [theme.breakpoints.up(1100 + theme.spacing(3 * 2))]: {
      width: 1100,
      marginLeft: "auto",
      marginRight: "auto"
    }
  },
}));

//Optional styling
const UINotificationsStyle = {
  NotificationItem: { // Override the notification item
    DefaultStyle: { // Applied to every notification, regardless of the notification level
      margin: '5px 5px 2px 1px'
    },
  }
};

export function App(props) {

  const { notifications } = {...props};
  changeDocumentTitle("Leads Management App");
  const classes = useStyles();
  const theme = createMuiTheme({
    palette: {
      type: 'light',
      primary: config.defaultPaletteColors.primary,
      secondary: config.defaultPaletteColors.secondary,
      contrastThreshold: 3,
      tonalOffset: 0.2,
    },
    typography: {
      fontSize: 14,
    },
  });

  return (
    <MuiThemeProvider theme={theme}>
      <CssBaseline />
      <Grid component="main" className={classes.root}>
        <Header />
        <Notifications
          notifications={notifications}
          style={UINotificationsStyle}
        />
        <Home />
      </Grid>
    </MuiThemeProvider>
  );
}

const mapStateToProps = (state) => {
  return {
    notifications: state.notifications,
  };
};

const mapDispatchToProps = (dispatch) => {
  return {
  };
};

export default connect(mapStateToProps, mapDispatchToProps)(App);