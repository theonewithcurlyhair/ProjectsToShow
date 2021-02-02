import React, { useState } from 'react';
import { makeStyles } from '@material-ui/core/styles';
import Card from '@material-ui/core/Card';
import TextField from '@material-ui/core/TextField';
import Switch from '@material-ui/core/Switch';
import FormControlLabel from "@material-ui/core/FormControlLabel";

import CardActions from '@material-ui/core/CardActions';
import IconButton from '@material-ui/core/IconButton';
import DoneIcon from '@material-ui/icons/Done';
import { createLeadService } from '../../services/leads-api';

import { useDispatch } from 'react-redux';
import { error as notificationError } from 'react-notification-system-redux';
import { notificationTemplate } from '../../redux/methods';
import { setLead as addLead } from '../../redux/actions/leads';

const useStyles = makeStyles((theme) => ({
  root: {
    '& .MuiTextField-root': {
      margin: theme.spacing(1),
      width: '95% ',
    },
  },
  shape: {
    width: 30,
    height: 30,
  },
  shapeCircle: {
    borderRadius: '25%',
  },
  colors: {
  	margin: theme.spacing(1),
  	'& > *': {
      margin: theme.spacing(1),
    },
  },
  card: {
    display: 'flex',
    flexDirection: 'column',
  },
  cardColor: {
    color: theme.palette.common.white,
  }
}));

function AddLead(props) {

  const { setDisplayAddLeadComponent } = {...props};
  const dispatch = useDispatch();
  const classes = useStyles();
  const [lead, setLead] = useState(
    {
      first_name: '', 
      last_name: '', 
      email: '',
      notes: '',
      contacted: false,
    });
  const [isLoading, setIsLoading] = useState(false);

  const handleSubmit = async event => {
    event.preventDefault();
    setIsLoading(true);
    try {
      // Api Call To Create Lead
      const response = await createLeadService(lead);
      // The Request Was Fulffiled And The Lead Was Created
      // So Let's Hide The AddLead Component
      setDisplayAddLeadComponent(false);
      // the response returns the created lead
      // we add it to our leads
      dispatch(addLead(response.data));
    } catch (error) {
        // display notification for error
        dispatch(notificationError({'title': error.request.statusText,
          'autoDismiss': 0,
          'message': `Failed to add lead`,
          'children': notificationTemplate.renderArray(error.response?.data?.errors),
        }));
    }
    setIsLoading(false);
  }

  const handleFieldChange = event => {
    const { name, value } = event.target;
    setLead(lead => ({ ...lead, [name]: value }));
	}

  const handleSwitchChange = (event) => {
    setLead(lead => ({ ...lead, [event.target.name]: event.target.checked }));
  };

return (
	<Card className={classes.card}>
    <form className={classes.root} noValidate>
      <div>
        <TextField
          id="filled-multiline-static"
          label="First name"
          name="first_name"
          multiline
          rowsMax={2}
          value={lead.firstName}
          onChange={handleFieldChange}
          variant="filled"
        />
        <TextField
          id="filled-multiline-static"
          label="Last name"
          name="last_name"
          multiline
          rowsMax={10}
          value={lead.lastName}
          onChange={handleFieldChange}
          variant="filled"
        />
        <TextField
          id="filled-multiline-static"
          label="Email"
          type="email"
          name="email"
          multiline
          rowsMax={2}
          value={lead.email}
          onChange={handleFieldChange}
          variant="filled"
        />
          <TextField
          id="filled-multiline-static"
          label="Notes"
          type="text"
          name="notes"
          multiline
          rowsMax={2}
          value={lead.notes}
          onChange={handleFieldChange}
          variant="filled"
        />
        <FormControlLabel
          control={
            <Switch
              checked={!!lead.contacted}
              onChange={handleSwitchChange}
              label="Contacted"
              name="contacted"
              inputProps={{ 'aria-label': 'secondary checkbox' }}
            />
          }
          label={lead.contacted ? 
            "contacted" : 
            "not contacted"}
          labelPlacement="start"
        />
      </div>
    </form>
		<CardActions>
      <IconButton onClick={handleSubmit} disabled={isLoading}>
        <DoneIcon />
      </IconButton>
		</CardActions>
  </Card>
  );
}


export default AddLead;