// import React from 'react';
// import { Icons } from '../../data/Icons';
// import './SideBar.css';
// import { useNavigate, useLocation } from 'react-router-dom';

// const SideBar = () => {
//     const navigate = useNavigate();
//     const location = useLocation();

//     // Define menu items with proper routes - only using the first 4 icons for main navigation
//     const menuItems = [
//         { 
//             route: '/layout/home', 
//             name: 'Home',
//             icon: Icons[0]?.icon
//         },
//         { 
//             route: '/layout/applications', 
//             name: 'Applications',
//             icon: Icons[1]?.icon
//         },
//         { 
//             route: '/layout/people', 
//             name: 'People',
//             icon: Icons[2]?.icon
//         },
//         { 
//             route: '/layout/Drivers', 
//             name: 'Drivers',
//             icon: Icons[3]?.icon
//         },
//         { 
//             route: '/layout/users', 
//             name: 'Users',
//             icon: Icons[4]?.icon
//         },
//         { 
//             route: '/layout/usersInfp', 
//             name: 'User Infp',
//             icon: Icons[5]?.icon
//         },
//         { 
//             route: '/layout/password', 
//             name: 'Password',
//             icon: Icons[6]?.icon
//         },
//         { 
//             route: '/layout/settings', 
//             name: 'Settings',
//             icon: Icons[7]?.icon
//         },
//         { 
//             route: '/layout/logout', 
//             name: 'Logout',
//             icon: Icons[8]?.icon
//         },
        
//     ];

//     const handleMenuClick = (route) => {
//         navigate(route);
//     };

//     // Check if menu item is active based on current location
//     const isActive = (route) => {
//         return location.pathname === route || location.pathname.startsWith(route + '/');
//     };

//     // Handle logout
//     const handleLogout = () => {
//         localStorage.removeItem('loggedIn');
//         navigate('/login');
//     };
//  const printDivider = (index) => {
//          if(index === 1 || index ===5)
//          {
//             <div className="menu-divider"></div>
//          }
//     };
//     return (
//         <div className="sidebar">
//             <div className="Profile">
//                 <img 
//                     src="/Resources/Choosing_ProfilePic/businessman.png" 
//                     alt="Profile" 
//                     className="Profile-Image" 
//                 />
//                 <div className="text">
//                     <span className="name">John Doe</span>
//                     <span className="Permetinos">Administrator</span>
//                 </div>
//             </div>

//             <div className="Menu">
//                 {menuItems.map((item, index) => (
//                     <div 
//                         className={`Menu-Item ${isActive(item.route) ? 'active' : ''}`} 
//                         key={index} 
//                         onClick={() => handleMenuClick(item.route)}
//                     >
//                         {item.icon && React.createElement(item.icon, { className: "Menu-Icon" })}
//                         <span className="Menu-Text">{item.name}</span>
//                         {printDivider(index)}
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

    // Define menu items with proper routes
    const menuItems = [
        { 
            route: '/layout/home', 
            name: 'Home',
            icon: Icons[0]?.icon
        },
        { 
            route: '/layout/applications', 
            name: 'Applications',
            icon: Icons[1]?.icon
        },
        { 
            route: '/layout/people', 
            name: 'People',
            icon: Icons[2]?.icon
        },
        { 
            route: '/layout/drivers',  // Fixed typo: Drivers -> drivers
            name: 'Drivers',
            icon: Icons[3]?.icon
        },
        { 
            route: '/layout/users', 
            name: 'Users',
            icon: Icons[4]?.icon
        },
        { 
            route: '/layout/userinfo',  // Fixed typo: usersInfp -> userinfo
            name: 'User Info',
            icon: Icons[5]?.icon
        },
        { 
            route: '/layout/password', 
            name: 'Password',
            icon: Icons[6]?.icon
        },
        { 
            route: '/layout/settings', 
            name: 'Settings',
            icon: Icons[7]?.icon
        },
        { 
            route: '/logout',  // Changed to simple route since it doesn't need layout
            name: 'Logout',
            icon: Icons[8]?.icon,
            isLogout: true
        },
    ];

    const handleMenuClick = (item) => {
        if (item.isLogout) {
            handleLogout();
        } else {
            navigate(item.route);
        }
    };

    // Check if menu item is active based on current location
    const isActive = (route) => {
        return location.pathname === route || location.pathname.startsWith(route + '/');
    };

    // Handle logout
    const handleLogout = () => {
        localStorage.removeItem('loggedIn');
        navigate('/login');
    };

    // Function to render dividers at specific indices
    const renderDivider = (index) => {
        if (index === 1 || index === 5) {
            return <div className="menu-divider" key={`divider-${index}`}></div>;
        }
        return null;
    };

    return (
        <div className="sidebar">
            <div className="Profile">
                <img 
                    src="/profiles/businessman.png" 
                    alt="Profile" 
                    className="Profile-Image" 
                />
                <div className="text">
                    <span className="name">Amine Aharkate</span>
                    <span className="Permetinos">Administrator</span>
                </div>
            </div>

            <div className="Menu">
                {menuItems.map((item, index) => (
                    <React.Fragment key={index}>
                        <div 
                            className={`Menu-Item ${isActive(item.route) ? 'active' : ''} ${item.isLogout ? 'logout-item' : ''}`} 
                            onClick={() => handleMenuClick(item)}
                        >
                            {item.icon && React.createElement(item.icon, { className: "Menu-Icon" })}
                            <span className="Menu-Text">{item.name}</span>
                        </div>
                        {renderDivider(index)}
                    </React.Fragment>
                ))}
            </div>
        </div>                 
    );  
}

export default SideBar;