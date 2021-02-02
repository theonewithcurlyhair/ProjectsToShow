import {
	FETCH_LEAD,
	FETCH_LEAD_SUCCESS,
	FETCH_LEAD_FAILURE,
	REFETCH_LEAD,
	REFETCH_LEAD_SUCCESS,
	REFETCH_LEAD_FAILURE,
	DELETE_LEAD,
	DELETE_LEAD_SUCCESS,
	DELETE_LEAD_FAILURE,

} from '../constants/leads';
import { error as notificationError } from 'react-notification-system-redux';
import { fetchLeadsService, fetchLeadService, 
	deleteLeadService } from '../../services/leads-api';
import { concatArrayOfObjectsAndSortWithDateAsc } from '../methods';

const ActionCreatorFactory = (type, payload=null) => {
	return {
		type: type,
		payload: payload
	}
}

const fetchLeads = page => ActionCreatorFactory(FETCH_LEAD);
const fetchLeadsSuccess = data => ActionCreatorFactory(FETCH_LEAD_SUCCESS, data);
const fetchLeadsError = error => ActionCreatorFactory(FETCH_LEAD_FAILURE, error);

export function getLeads() {
	return (dispatch) => {
		dispatch(fetchLeads());
		fetchLeadsService()
		.then((response) => {
			if (response.status !== 200) {
				dispatch(fetchLeadsError(response));
			}
			return response;
		})
		.then((response) => {
			dispatch(fetchLeadsSuccess(response.data))
		})
		.catch((error) => {
			console.log("error =>", error)
			dispatch(fetchLeadsError(error));
			dispatch(notificationError({'title': error.response.data.message || 
				error.request.statusText,
				'message': `Failed to load Leadss`,
			}));
		})
	};
}

export const setLead = (lead) => {
	return (dispatch, getState) => {
		if(lead) {
			let leads = getState().leads.leads;
			leads = concatArrayOfObjectsAndSortWithDateAsc(leads, [lead])
			dispatch(fetchLeadsSuccess(leads));
			return;
		}
	}
}

const refetchLeads = page => ActionCreatorFactory(REFETCH_LEAD);
const refetchLeadsSuccess = data => ActionCreatorFactory(REFETCH_LEAD_SUCCESS, data);
const refetchLeadsError = error => ActionCreatorFactory(REFETCH_LEAD_FAILURE, error);

export const refetchLead = id => {
	return (dispatch) => {
		dispatch(refetchLeads());
		fetchLeadService(id)
		.then((response) => {
			if (response.status !== 200) {
				dispatch(refetchLeadsError(response));
			}
			return response;
		})
		.then((response) => {
			dispatch(refetchLeadsSuccess(response.data));
		})
		.catch((error) => {
			dispatch(refetchLeadsError(error));
			dispatch(notificationError({'title': error.response.data.message || 
				error.request.statusText,
				'message': `Failed to refetch lead`,
			}));
		})
	}
}

const removeLead = page => ActionCreatorFactory(DELETE_LEAD);
const removeLeadSuccess = data => ActionCreatorFactory(DELETE_LEAD_SUCCESS, data);
const removeLeadError = error => ActionCreatorFactory(DELETE_LEAD_FAILURE, error);

export const deleteLead = id => {
	return (dispatch) => {
		dispatch(removeLead());
		deleteLeadService(id)
		.then((response) => {
			if (response.status !== 200) {
				dispatch(removeLeadError(response));
			}
			return response;
		})
		.then((response) => {
			dispatch(removeLeadSuccess({lead: response.data?.lead, lead_id: id}));
		})
		.catch((error) => {
			dispatch(removeLeadError(error));
			dispatch(notificationError({'title': error.response.data.message || 
				error.request.statusText,
				'message': `Failed to delete lead`,
			}));
		})
	}
}
