import React, {useState} from 'react';
import { useSearchParams } from 'react-router-dom';
import authService from '../services/authService';

const DoLogin = () => {
  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');
  const [message, setMessage] = useState('');

  const handleLogin = async(e) => {
    e.preventDefault();

    try{
      await authService.login(username, password);
      window.location.reload();
    } catch (error){
      setMessage('Erro ao realizar login: ' + error.response.data.message);
    }
  }

  return (
    <div>
    <form onSubmit={handleLogin}>
      <div>
        <label>Username</label>
        <input
          type="text"
          value={username}
          onChange={(e) => setUsername(e.target.value)}
        />
      </div>
      <div>
        <label>Password</label>
        <input
          type="password"
          value={password}
          onChange={(e) => setPassword(e.target.value)}
        />
      </div>
      <button type="submit">Login</button>
    </form>
    {message && <div>{message}</div>}
  </div>
  );
};

export default DoLogin;
