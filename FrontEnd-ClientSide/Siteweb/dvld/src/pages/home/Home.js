// import React from 'react';
// import './home.css';

// const Home = () => {
//     return (
//         <div>
//             <h1>Main Home Page of DVLD </h1>;
//         </div>
//     );
// }

// export default Home;

import React from 'react';
import './home.css';

const Home = () => {
    return (
        <div className="home-wrapper">
            <h1 className="home-title">Main Home Page of DVLD</h1>
            <p className="home-description">
                Welcome to the DVLD system — your gateway to futuristic vehicle licensing.
                Here, you can explore services, track applications, and enjoy a neon-powered dashboard experience.
            </p>
            <div className="home-card">
                <h2> Featured Services</h2>
                <ul>
                    <li>License Renewal Portal</li>
                    <li>Vehicle Registration Tracker</li>
                    <li>Digital just nothing is here</li>
                    <li>and more and more </li>
                </ul>
            </div>
        </div>
    );
}

export default Home;
