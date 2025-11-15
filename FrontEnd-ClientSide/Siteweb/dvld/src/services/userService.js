import axios from 'axios';

const API_BASE_URL = 'http://localhost:5045/api'; 

const userService = {
    
    authenticateUser: async (userName, password) => {
        try {

            const response = await axios.get(`${API_BASE_URL}/userService/GetUserInfoByUsernameAndPassword/${userName}/${password}`);
            return response.data;

        } catch (error) {

            if (error.response && error.response.status === 404) {
                throw new Error('Invalid username or password s ');
            } else if (error.response && error.response.status === 400) {
                throw new Error('Username and password cannot be empty s');
            } else {
                throw new Error('An error occurred during login s');
            }
        }
    }

};

export default userService;