import React from 'react'
import Card from '@material-ui/core/Card';
import CardContent from '@material-ui/core/CardContent';
import CardActions from '@material-ui/core/CardActions';
import IconButton from '@material-ui/core/IconButton';
import AutorenewIcon from '@material-ui/icons/Autorenew';
import Grid from '@material-ui/core/Grid';
import Typography from '@material-ui/core/Typography';
import { makeStyles } from '@material-ui/core/styles';
import LeadsCard from './Lead/LeadsCard';
import Fade from '@material-ui/core/Fade';

const useStyles = makeStyles((theme) => ({
  icon: {
    marginRight: theme.spacing(2),
  },
  cardGrid: {
    paddingTop: theme.spacing(2),
    paddingBottom: theme.spacing(2),
  },
  card: {
    height: '100%',
    display: 'flex',
    flexDirection: 'column',
  },
  cardContent: {
    flexGrow: 1,
  },
}));

const Leads = (props) => {

	const { leads, loadLeads, label } = {...props};
	const classes = useStyles();

	return (
		<React.Fragment>
			{leads && leads.length >= 1
				?
					<React.Fragment>
						<Grid container className={classes.cardGrid} spacing={2}>
							{leads.map((lead) => (
								<Fade in={true}>
									<LeadsCard lead={lead} key={lead.id} />
								</Fade>
							))}
						</Grid>
					</React.Fragment>
				:
					<React.Fragment>
							<Grid container className={classes.cardGrid} spacing={4}>
								<Grid item xs={12} sm={6} md={4}>
									<Card className={classes.card}>
										<CardContent className={classes.cardContent}>
											<Typography gutterBottom 
											variant="h6" 
											component="h6">
											{`No leads in ${label}`}
											</Typography>
										</CardContent>
										<CardActions>
					            <IconButton onClick={loadLeads} title={`Refresh ${label}`}
					              className={classes.icons}>
					              <AutorenewIcon />
					            </IconButton>
										</CardActions>
									</Card>
								</Grid>
							</Grid>
					</React.Fragment>
			}
		</React.Fragment>
	);
}

export default Leads;
