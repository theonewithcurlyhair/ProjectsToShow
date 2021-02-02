import React, { useState, useEffect } from 'react';
import Leads from '../components/Leads';
import { makeStyles } from '@material-ui/core';
import IconButton from '@material-ui/core/IconButton';
import WatchLaterIcon from '@material-ui/icons/WatchLater';
import NoteAddIcon from '@material-ui/icons/NoteAdd';
import Divider from '@material-ui/core/Divider';
import { getLeads } from '../redux/actions/leads';
import { connect } from 'react-redux';
import AddLead from '../components/Lead/AddLead'

export const useStyles = makeStyles((theme) => ({
  card: {
    display: "flex",
    margin: theme.spacing(1),
    boxShadow: 'none !important'
  },
  cardDetails: {
    flex: 1
  },
  cardMedia: {
    minWidth: 160,
  },
  a: {
    textDecoration: 'none',
    color: theme.palette.secondary.main
  },
  divider: {
    margin: theme.spacing(1, 0, 2, 0),
  }
}));


const Home = (props) => {
	
  const { leads, loadLeads } = {...props};
	const classes = useStyles();
  const [displayAddLeadComponent, setDisplayAddLeadComponent] = useState(false);

  useEffect(
    () => {
      if (
          !leads.leads.length && 
          !leads.isLoading && 
          !leads.isLoaded &&
          !leads.isError) loadLeads()
    }, 
    [leads, loadLeads]
  );

	return (
		<React.Fragment>
      <IconButton onClick={() => setDisplayAddLeadComponent(!displayAddLeadComponent)}>
        <NoteAddIcon />
      </IconButton>
      <Divider className={classes.divider} />
      {displayAddLeadComponent &&
        <React.Fragment>
          <AddLead 
            setDisplayAddLeadComponent={setDisplayAddLeadComponent} />
          <Divider className={classes.divider} />
        </React.Fragment>
      }
      <IconButton>
        <WatchLaterIcon />
      </IconButton>
      <Leads leads={leads.leads} 
        loadLeads={loadLeads} 
        label='Recent' />
		</React.Fragment>
	);
}

const mapStateToProps = (state) => {
  return {
    leads: state.leads,
  };
};

const mapDispatchToProps = (dispatch) => {
  return {
    loadLeads: () => dispatch(getLeads()),
  };
};

export default connect(mapStateToProps, mapDispatchToProps)(Home);