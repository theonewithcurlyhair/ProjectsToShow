import { FETCH_LEAD,
	FETCH_LEAD_SUCCESS, 
	FETCH_LEAD_FAILURE,
	REFETCH_LEAD_SUCCESS,
	DELETE_LEAD_SUCCESS,
	 } from '../constants/leads';
import { filterArrayWithId, concatArrayOfObjectsAndSortWithDateAsc } from '../methods';

const INITIAL_STATE = {
		leads: [],
		count: 0,
		isLoading: false,
		isLoaded: false,
};

function leads(state=INITIAL_STATE, action) {

	switch (action.type){
		case FETCH_LEAD: {
			return {...INITIAL_STATE, 
					isLoading: true
				}
			}
		case FETCH_LEAD_SUCCESS: {
			return {...state,
					leads: concatArrayOfObjectsAndSortWithDateAsc(action.payload || state.leads),
					count: state.leads.length,
					isLoading: false,
					isLoaded: true, 
				}
			}
		case FETCH_LEAD_FAILURE: {
			return {...state, 
					isLoading: false,
					isLoaded: true, 
				}
			}
		case REFETCH_LEAD_SUCCESS: {
			return {...state, 
					leads: concatArrayOfObjectsAndSortWithDateAsc(
						filterArrayWithId(state.leads, action.payload?.id), [action.payload]),
					count: state.leads.length,
			}
		}
		case DELETE_LEAD_SUCCESS: {
			return {...state,
					leads: filterArrayWithId(state.leads, action.payload.lead_id),
					count: state.leads.length,
					isLoading: false,
					isLoaded: true,
				}
		}
		default:
			return state;
	}
}

export default leads;
