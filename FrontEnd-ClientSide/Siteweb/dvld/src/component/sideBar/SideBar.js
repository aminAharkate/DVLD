// import React from 'react';
// import { Icons } from '../../data/Icons';
// import './SideBar.css';
// import { useNavigate } from 'react-router-dom';
// import { Link } from "react-router-dom";


// const SideBar = () => {
//     const [activeIndex, setActiveIndex] = React.useState(0);
//     const navigate = useNavigate();

//     const handleMenuClick = (index, route) => {
//         setActiveIndex(index);
//         navigate(route);
//         <Link to="/Layout" style={{ color: "white" }}>🏠 الرئيسية</Link>


//     };

//     // Define routes for each menu item
//     const menuRoutes = [
//         '/Home',      
//         '/People',     
//         '/users',    
//         '/Login',   
//         '/Settings',    
      
//     ];

//     return (
//         <div className="sidebar">
//             <div className="Profile">
//                 <img 
//                     src="Resources/Choosing_ProfilePic/businessman.png" 
//                     alt="Profile" 
//                     className="Profile-Image" 
//                 />
//                 <div className="text">
//                     <span className="name">John Doe</span>
//                     <span className="Permetinos">Administrator</span>
//                 </div>
//             </div>

//             <div className="Menu">
//                 {Icons.map((item, index) => (
//                     <div 
//                         className={`Menu-Item ${activeIndex === index ? 'active' : ''}`} 
//                         key={index} 
//                         onClick={() => handleMenuClick(index, menuRoutes[index] || '/Dashboard')}
//                     >
//                         <item.icon className="Menu-Icon" />
//                         <span className="Menu-Text">{item.name}</span>
//                     </div>
//                 ))}
//             </div>
//         </div>                 
//     );  
// }

// export default SideBar;
import React from 'react';
import { Icons } from '../../data/Icons';
import './SideBar.css';
import { useNavigate, useLocation } from 'react-router-dom';

const SideBar = () => {
    const navigate = useNavigate();
    const location = useLocation();

    // Define routes for each menu item
    const menuItems = [
        { route: '/Layout/home', name: 'Home' },
        { route: '/Layout/people', name: 'People' },
        { route: '/Layout/users', name: 'Users' },
        { route: '/Layout/settings', name: 'Settings' },
    ];

    const handleMenuClick = (route) => {
        navigate(route);
    };

    // Check if menu item is active based on current location
    const isActive = (route) => {
        return location.pathname === route;
    };

    return (
        <div className="sidebar">
            <div className="Profile">
                <img 
                    src="Resources/Choosing_ProfilePic/businessman.png" 
                    alt="Profile" 
                    className="Profile-Image" 
                />
                <div className="text">
                    <span className="name">John Doe</span>
                    <span className="Permetinos">Administrator</span>
                </div>
            </div>

            <div className="Menu">
                {Icons.slice(0, 3).map((item, index) => (
                    <div 
                        className={`Menu-Item ${isActive(menuItems[index].route) ? 'active' : ''}`} 
                        key={index} 
                        onClick={() => handleMenuClick(menuItems[index].route)}
                    >
                        <item.icon className="Menu-Icon" />
                        <span className="Menu-Text">{menuItems[index].name}</span>
                    </div>
                ))}
            </div>
        </div>                 
    );  
}

export default SideBar;