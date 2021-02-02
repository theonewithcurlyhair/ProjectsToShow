import axios from 'axios';

export const fetchLeadsService = () => axios.get(`/api/leads/`);
export const fetchLeadService = id => axios.get(`/api/leads/${id}/`);
export const createLeadService = formData => axios.post(`/api/leads/`, {...formData});
export const updateLeadService = formData => axios.put(`/api/leads/${formData.id}/`, {...formData});
export const deleteLeadService = id => axios.delete(`/api/leads/${id}/`);
