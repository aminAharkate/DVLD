import React from 'react';
import userService from './../../services/userService';
import { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import './Login.css';


const Login = () => {


  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');
  const [rememberMe, setRememberMe] = useState(false);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState('');
  const navigate = useNavigate();

const handleLogin = async (e) => {

    e.preventDefault();
    setError('');
    setLoading(true);

    try {
            if (!username.trim() || !password.trim()) {
              setError('Please enter both username and password');
              setLoading(false);
              return;
            }
            const userData = await userService.authenticateUser(username, password);

            console.log('Login successful:', userData);
            localStorage.setItem("loggedIn", "true");

            if (rememberMe) {
              localStorage.setItem('user', JSON.stringify(userData));
            } else {
              sessionStorage.setItem('user', JSON.stringify(userData));
            }
            navigate('/layout/home');
  
      
    } catch (err) {
      setError(err.message);
    } finally {
      setLoading(false);
    }
  }

    return (
              <div className="login-page">
            <div className="login-container">
            <h2>Driving & Vehicle License Department</h2>
            
            {error && (
                <div className="error-message" style={{color: 'red', marginBottom: '10px'}}>
                {error}
                </div>
            )}
            
            <form onSubmit={handleLogin}>
                <label htmlFor="username">User Name:</label>
                <input 
                type="text" 
                id="username" 
                placeholder="Please enter your user name" 
                value={username}
                onChange={(e) => setUsername(e.target.value)}
                disabled={loading}
                />
                
                <label htmlFor="password">Password:</label>
                <input
                type="password"
                id="password"
                placeholder="Please enter your password"
                value={password}
                onChange={(e) => setPassword(e.target.value)}
                disabled={loading}
                />
                
                <div>
                <input 
                    type="checkbox" 
                    id="remember" 
                    checked={rememberMe}
                    onChange={(e) => setRememberMe(e.target.checked)}
                    disabled={loading}
                />
                <label htmlFor="remember">Remember Me</label>
                </div>
                
                <button type="submit" disabled={loading}>
                {loading ? 'Logging in...' : 'Log in'}
                </button>
            </form>
            
            <div className="version">version 2.6.1</div>
            </div>
            </div>
    );
}

export default Login;
