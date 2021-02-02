import React, { useState } from 'react';
import Card from '@material-ui/core/Card';
import CardContent from '@material-ui/core/CardContent';
import Grid from '@material-ui/core/Grid';
import Typography from '@material-ui/core/Typography';
import { makeStyles } from '@material-ui/core/styles';
import EditLead from './EditLead';
import DialogWithCallback from '../Common/DialogWithCallback';
import { deleteLead } from '../../redux/actions/leads';
import { connect } from 'react-redux';
import CardActions from '@material-ui/core/CardActions';
import DeleteIcon from '@material-ui/icons/Delete';
import EditIcon from '@material-ui/icons/Edit';
import IconButton from '@material-ui/core/IconButton';
import formatDistanceToNow from 'date-fns/formatDistanceToNow';

const useStyles = makeStyles((theme) => ({
  icon: {
    margin: theme.spacing(1, 1, 0, 0),
    width: 20,
    height: 20,
  },
  card: {
    display: 'flex',
    flexDirection: 'column',
  },
  cardContent: {
    flexGrow: 1,
  },
}));

function LeadsCard(props) {

	const { lead, deleteLead } = {...props};
	const classes = useStyles();
	const [toggleDisplay, setToggleDisplay] = useState(false);
	const [toggleEdit, setToggleEdit] = useState(false);
	const [toggleDelete, setToggleDelete] = useState(false);

	const handleToggleActions = (action) => {
		if(action === "toggleEdit") {
			setToggleEdit(!toggleEdit);
			if(toggleDisplay) {
				setToggleDisplay(false);
			}
		}
		if(action === "toggleDisplay") {
			setToggleDisplay(!toggleDisplay);
			if(toggleEdit) {
				setToggleEdit(false);
			}
		}
		if(action === "toggleDelete") {
			setToggleDelete(!toggleDelete);
			if(toggleEdit) {
				setToggleEdit(false);
			}
		}
	}

	return (
		<Grid item key={lead.id} xs={12} sm={6} md={4}>
			{!toggleEdit
				?
				<Card className={classes.card}>
					<CardContent className={classes.cardContent}>
						<Typography gutterBottom 
						variant="h4" 
						component="h4">
							{`${lead.first_name} ${lead.last_name}`}
						</Typography>
						<Typography gutterBottom 
						variant="h5" 
						component="h5">
							{lead.email}
						</Typography>
						<Typography  
						variant="h6" 
						component="h6" 
						gutterBottom>
							{!!lead.notes
								?
								"Notes: " + lead.notes
								:
								'Notes: No notes'
							}
						</Typography>
						<Typography  
							variant="body2" 
							component="body2"
							gutterBottom>
							{!!lead.contacted
								?
								"Contacted: Yes"
								:
								'Contacted: No'
							}
						</Typography>
						<Typography  
							variant="body2" 
							component="p"
							gutterBottom>
							{ 
							!!lead.created_at
							&&
								` Created ${formatDistanceToNow(new Date (Date.parse(lead.created_at)))} ago`
							}
						</Typography>
						<Typography  
							variant="body2" 
							component="p"
							gutterBottom>
							{ 
							!!lead.updated_at 
							&&
								` Updated ${formatDistanceToNow(new Date (Date.parse(lead.updated_at)))} ago`
							}
						</Typography>
					</CardContent>
					<CardActions>
						<IconButton onClick={() => handleToggleActions("toggleDelete")} title="Delete note">
							<DeleteIcon />
						</IconButton>
						<IconButton onClick={() => handleToggleActions("toggleEdit")} title="Edit note">
							<EditIcon />
						</IconButton>
					</CardActions>
				</Card>
				:
					<EditLead lead={lead} 
						handleToggleActions={handleToggleActions} />
			}
			{toggleDelete &&
				<DialogWithCallback 
					actionCallback={() => deleteLead(lead.id)}
					actionName="Delete"
					title="Delete lead"
					body={`Click delete to delete this lead`}
				/>
			}
		</Grid>
	);
}

const mapStateToProps = (state) => {
  return {
    leads: state.leads,
  };
};

const mapDispatchToProps = (dispatch) => {
  return {
    deleteLead: id => dispatch(deleteLead(id)),
  };
};

export default connect(mapStateToProps, mapDispatchToProps)(LeadsCard);