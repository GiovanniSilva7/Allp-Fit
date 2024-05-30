import axios from 'axios';
import { ApiBaseUrl } from './apiService';
import { Component } from 'react';


class Login extends Component{
  constructor(props){
    super(props);
    this.state = {
      email: '',
      password: '',
      errorMessage: ''
    }
  }

  updateFields = (field) => {
    this.setState({ [field.target.name] : field.target.value })
  }

  logar = (event) => {

    event.preventDefault()

    this.setState({erroMensagem : '', isLoading : true})

    axios.post( ApiBaseUrl + "/auth/login", {
        email : this.state.email,
        senha : this.state.senha
    })

    .then(resposta => {
        if(resposta.status === 200)
        {
            localStorage.setItem("user-token" , resposta.data.token);
            this.setState({isLoading : false});
        }
    })

    .catch( () => {
        this.setState({erroMensagem : 'Email ou senha incorretos! Tente novamente', isLoading : false})
    })
}}

const logout = () => {
  localStorage.removeItem('user');
};

const getCurrentUser = () => {
  return JSON.parse(localStorage.getItem('user'));
};

const parseJwt = () => {
  let base64 = localStorage.getItem('user-token').split('.')[1]

  return JSON.parse(window.atob(base64))
}

export default {
  Login,
  logout,
  getCurrentUser,
  parseJwt
};