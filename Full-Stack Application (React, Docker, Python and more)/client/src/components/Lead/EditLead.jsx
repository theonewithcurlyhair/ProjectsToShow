import React, { useState } from 'react';
import { makeStyles } from '@material-ui/core/styles';
import Card from '@material-ui/core/Card';
import TextField from '@material-ui/core/TextField';
import Switch from '@material-ui/core/Switch';
import FormControlLabel from "@material-ui/core/FormControlLabel";

import CardActions from '@material-ui/core/CardActions';
import DeleteForeverIcon from '@material-ui/icons/DeleteForever';
import EditIcon from '@material-ui/icons/Edit';
import IconButton from '@material-ui/core/IconButton';
import NoteIcon from '@material-ui/icons/Note';
import DoneIcon from '@material-ui/icons/Done';
import { updateLeadService } from '../../services/leads-api';

import {connect} from 'react-redux';
import { error as notificationError } from 'react-notification-system-redux';
import { refetchLead } from '../../redux/actions/leads';
import PropTypes from 'prop-types';

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
    margin: theme.spacing(0.5)
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
}));

function EditLead(props) {

	const { lead, handleToggleActions, addNotification, refetchLead } = {...props};
  const classes = useStyles();
  const [leadUpdate, setLeadUpdate] = useState(
  	{
      id: lead.id,
  		first_name: lead.first_name, 
      last_name: lead.last_name, 
      email: lead.email, 
      notes: lead.notes, 
  		contacted: lead.contacted, 
    });

  const [isLoading, setIsLoading] = useState(false);

  const handleSubmit = async event => {
    event.preventDefault();
    setIsLoading(true);
    try {
      // Api Call To Create Lead
      await updateLeadService(leadUpdate);
      refetchLead(lead.id);
      // The Request Was Fulffiled And The Lead Was updated
      // So Let's Hide The EditLead Component
      handleToggleActions("toggleDisplay");
    } catch (error) {
        // display notification for error
        addNotification({'title': error.response.data.message || 
          error.request.statusText,
          'message': `Failed to edit lead`,
        }, notificationError);
    }
    setIsLoading(false);
  }

  const handleFieldChange = event => {
    const { name, value } = event.target;
    setLeadUpdate(leadUpdate => ({ ...leadUpdate, [name]: value }));
	}

  const handleSwitchChange = (event) => {
    setLeadUpdate(leadUpdate => ({ ...leadUpdate, [event.target.name]: event.target.checked }));
  };

return (
	<Card className={classes.card}>
    <form className={classes.root} noValidate autoComplete="off">
      <div>
        <TextField
          id="filled-multiline-static"
          label="First name"
          name="first_name"
          multiline
          rowsMax={2}
          value={leadUpdate.first_name}
          onChange={handleFieldChange}
          variant="filled"
        />
        <TextField
          id="filled-multiline-static"
          label="Last name"
          name="last_name"
          multiline
          rowsMax={10}
          value={leadUpdate.last_name}
          onChange={handleFieldChange}
          variant="filled"
        />
        <TextField
          id="filled-multiline-static"
          label="Email"
          name="email"
          multiline
          rowsMax={2}
          value={leadUpdate.email}
          onChange={handleFieldChange}
          variant="filled"
        />
        <TextField
          id="filled-multiline-static"
          label="Notes"
          name="notes"
          multiline
          rowsMax={2}
          value={leadUpdate.notes}
          onChange={handleFieldChange}
          variant="filled"
        />
        <FormControlLabel
          control={
            <Switch
              checked={!!leadUpdate.contacted}
              onChange={handleSwitchChange}
              label="Contacted"
              name="contacted"
              inputProps={{ 'aria-label': 'secondary checkbox' }}
            />
          }
          label={leadUpdate.contacted ? 
            "contacted" : 
            "not contacted"}
          labelPlacement="start"
        />
      </div>
    </form>
		<CardActions>
			<IconButton onClick={() => handleToggleActions("toggleDisplay")}>
				<NoteIcon />
			</IconButton>
			<IconButton>
				<DeleteForeverIcon />
			</IconButton>
			<IconButton onClick={() => handleToggleActions("toggleEdit")}>
				<EditIcon />
			</IconButton>
      <IconButton onClick={handleSubmit} disabled={isLoading}>
        <DoneIcon />
      </IconButton>
		</CardActions>
  </Card>
  );
}

EditLead.propTypes = {
  lead: PropTypes.object,
  handleToggleActions: PropTypes.func.isRequired,
  addNotification: PropTypes.func.isRequired,
  refetchLead: PropTypes.func.isRequired,
};

const mapStateToProps = (state) => {
  return {
  };
};

const mapDispatchToProps = (dispatch) => {
  return {
    refetchLead: id => dispatch(refetchLead(id)),
    addNotification: (data, level) => dispatch(level(data)),
  };
};
export default connect(mapStateToProps, mapDispatchToProps)(EditLead);
