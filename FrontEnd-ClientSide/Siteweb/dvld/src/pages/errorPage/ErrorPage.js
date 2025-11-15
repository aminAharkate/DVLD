// src/pages/error/ErrorPage.js
import React from 'react';
import { useNavigate, useLocation } from 'react-router-dom';
import './ErrorPage.css';

const ErrorPage = () => {
    const navigate = useNavigate();
    const location = useLocation();

    const handleGoHome = () => {
        navigate('/layout/home');
    };

    const handleGoBack = () => {
        navigate(-1);
    };

    const handleGoLogin = () => {
        navigate('/login');
    };

    // Extract the invalid path from location
    const invalidPath = location.pathname;

    return (
        <div className="error-container">
            <div className="error-background">
                <div className="error-glow error-glow-1"></div>
                <div className="error-glow error-glow-2"></div>
                <div className="error-glow error-glow-3"></div>
            </div>
            
            <div className="error-content">
                <div className="error-code">
                    <span className="error-digit">4</span>
                    <span className="error-digit">0</span>
                    <span className="error-digit">4</span>
                </div>
                
                <div className="error-message">
                    <h1>Page Not Found</h1>
                    <p className="error-description">
                        The page you're looking for doesn't exist or has been moved.
                    </p>
                    <p className="error-path">
                        Requested path: <span>{invalidPath}</span>
                    </p>
                </div>

                <div className="error-actions">
                    <button className="error-btn error-btn-primary" onClick={handleGoBack}>
                        <span className="btn-icon">↶</span>
                        Go Back
                    </button>
                    <button className="error-btn error-btn-secondary" onClick={handleGoHome}>
                        <span className="btn-icon">🏠</span>
                        Go Home
                    </button>
                    <button className="error-btn error-btn-tertiary" onClick={handleGoLogin}>
                        <span className="btn-icon">🔐</span>
                        Login Page
                    </button>
                </div>

                <div className="error-help">
                    <p>If you believe this is an error, please contact support.</p>
                    <div className="error-contact">
                        <span>📧 support@dvld.gov</span>
                        <span>📞 1-800-DVLD-HELP</span>
                    </div>
                </div>
            </div>

            <div className="error-footer">
                <p>DVLD System • Driving & Vehicle License Department</p>
            </div>
        </div>
    );
};

export default ErrorPage;