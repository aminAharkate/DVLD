// import React from 'react';
// import './User.css'

// const Users = () => {
//     return (
//         <div>
//             <h1>User page</h1>
//         </div>
//     );
// }

// export default Users;
import React, { useState, useRef } from 'react';
import './User.css';

const Users = () => {
    // Fake users data
    const [users, setUsers] = useState([
        { id: 1, name: 'Alice Johnson', email: 'alice@email.com', role: 'Admin', status: 'Active', joinDate: '2023-01-15' },
        { id: 2, name: 'Bob Smith', email: 'bob@email.com', role: 'User', status: 'Active', joinDate: '2023-02-20' },
        { id: 3, name: 'Carol Davis', email: 'carol@email.com', role: 'Moderator', status: 'Inactive', joinDate: '2023-03-10' },
        { id: 4, name: 'David Wilson', email: 'david@email.com', role: 'User', status: 'Active', joinDate: '2023-04-05' },
        { id: 5, name: 'Eva Brown', email: 'eva@email.com', role: 'User', status: 'Pending', joinDate: '2023-05-12' },
        { id: 6, name: 'Frank Miller', email: 'frank@email.com', role: 'Admin', status: 'Active', joinDate: '2023-06-18' }
    ]);

    const [searchTerm, setSearchTerm] = useState('');
    const [contextMenu, setContextMenu] = useState({ visible: false, x: 0, y: 0, user: null });
    const contextMenuRef = useRef(null);

    // Filter users based on search term
    const filteredUsers = users.filter(user =>
        user.name.toLowerCase().includes(searchTerm.toLowerCase()) ||
        user.email.toLowerCase().includes(searchTerm.toLowerCase()) ||
        user.role.toLowerCase().includes(searchTerm.toLowerCase())
    );

    // Handle context menu
    const handleContextMenu = (e, user) => {
        e.preventDefault();
        setContextMenu({
            visible: true,
            x: e.clientX,
            y: e.clientY,
            user: user
        });
    };

    // Close context menu
    const closeContextMenu = () => {
        setContextMenu({ visible: false, x: 0, y: 0, user: null });
    };

    // Handle context menu actions
    const handleContextAction = (action) => {
        if (contextMenu.user) {
            alert(`Action: ${action} for user: ${contextMenu.user.name}`);
            // Here you would implement the actual action logic
        }
        closeContextMenu();
    };

    // Close context menu when clicking outside
    React.useEffect(() => {
        const handleClickOutside = (event) => {
            if (contextMenuRef.current && !contextMenuRef.current.contains(event.target)) {
                closeContextMenu();
            }
        };

        document.addEventListener('mousedown', handleClickOutside);
        return () => {
            document.removeEventListener('mousedown', handleClickOutside);
        };
    }, []);

    return (
        <div className="users-container" onClick={closeContextMenu}>
            <h1 className="users-title">Users Page</h1>
            
            {/* Search Box */}
            <div className="search-container">
                <input
                    type="text"
                    placeholder="Search users by name, email, or role..."
                    value={searchTerm}
                    onChange={(e) => setSearchTerm(e.target.value)}
                    className="search-input"
                />
            </div>

            {/* Users Table */}
            <div className="table-wrapper">
                <table className="users-table">
                    <thead>
                        <tr className="table-header">
                            <th>ID</th>
                            <th>Name</th>
                            <th>Email</th>
                            <th>Role</th>
                            <th>Status</th>
                            <th>Join Date</th>
                        </tr>
                    </thead>
                    <tbody>
                        {filteredUsers.map(user => (
                            <tr 
                                key={user.id} 
                                className="table-row"
                                onContextMenu={(e) => handleContextMenu(e, user)}
                            >
                                <td>{user.id}</td>
                                <td>{user.name}</td>
                                <td>{user.email}</td>
                                <td>
                                    <span className={`role-badge role-${user.role.toLowerCase()}`}>
                                        {user.role}
                                    </span>
                                </td>
                                <td>
                                    <span className={`status-badge status-${user.status.toLowerCase()}`}>
                                        {user.status}
                                    </span>
                                </td>
                                <td>{user.joinDate}</td>
                            </tr>
                        ))}
                    </tbody>
                </table>
                
                {filteredUsers.length === 0 && (
                    <div className="no-results">
                        No users found matching your search.
                    </div>
                )}
            </div>

            {/* Context Menu */}
            {contextMenu.visible && (
                <div 
                    ref={contextMenuRef}
                    className="context-menu"
                    style={{
                        position: 'fixed',
                        top: contextMenu.y,
                        left: contextMenu.x
                    }}
                >
                    <div className="context-menu-header">
                        Actions for {contextMenu.user?.name}
                    </div>
                    <div className="context-menu-item" onClick={() => handleContextAction('Edit')}>
                        Edit User
                    </div>
                    <div className="context-menu-item" onClick={() => handleContextAction('Delete')}>
                        Delete User
                    </div>
                    <div className="context-menu-item" onClick={() => handleContextAction('View Profile')}>
                        View Profile
                    </div>
                    <div className="context-menu-item" onClick={() => handleContextAction('Send Message')}>
                        Send Message
                    </div>
                    <div className="context-menu-item" onClick={() => handleContextAction('Change Role')}>
                        Change Role
                    </div>
                </div>
            )}
        </div>
    );
}

export default Users;
