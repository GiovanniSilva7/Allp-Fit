import axios from 'axios';
import authService from './authService';

export const ApiBaseUrl = "https://localhost:7234/api/";

const Api = () => {
  const api = axios.create({
    baseURL: ApiBaseUrl,
    headers: {
      'Content-Type': 'application/json'
    }
  });
  
  api.interceptors.request.use(
    config => {
      const user = authService.getCurrentUser();
      if(user & user.token){
        config.headers['Authorization'] = 'Bearer ' + user.token;
      }
  
      return config;
    },
    error => {
      Promise.reject(error);
    }
  )
}

export default {
  Api,
  ApiBaseUrl
}

