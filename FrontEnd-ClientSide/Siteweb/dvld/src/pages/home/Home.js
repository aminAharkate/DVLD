import React from 'react';
import './home.css';

const Home = () => {
    return (
        <div className="home-wrapper">
            <header className="home-header">
                <div className="header-content">
                    <h1 className="home-title">Driving & Vehicle License Department</h1>
                    <p className="home-subtitle">Digital Licensing Management System</p>
                </div>
            </header>

            <main className="home-main">
                <section className="hero-section">
                    <div className="hero-content">
                        <h2>Welcome to DVLD Portal</h2>
                        <p className="hero-description">
                            Streamline your driving license applications, renewals, and management through our 
                            comprehensive digital platform.
                        </p>
                        <div className="cta-buttons">
                            <button className="cta-primary">Get Started</button>
                            <button className="cta-secondary">Learn More</button>
                        </div>
                    </div>
                </section>

                <section className="services-section">
                    <h3 className="section-title">Our Services</h3>
                    <div className="services-grid">
                        <div className="service-card">
                            <div className="service-icon">🚗</div>
                            <h4>First-Time License</h4>
                            <p>Apply for your first driving license with step-by-step guidance</p>
                            <span className="service-fee">Fee: $5 + License Cost</span>
                        </div>
                        
                        <div className="service-card">
                            <div className="service-icon">🔄</div>
                            <h4>License Renewal</h4>
                            <p>Renew your existing driving license before expiration</p>
                            <span className="service-fee">Fee: $5</span>
                        </div>
                        
                        <div className="service-card">
                            <div className="service-icon">📄</div>
                            <h4>Duplicate License</h4>
                            <p>Replace lost or damaged licenses with new copies</p>
                            <span className="service-fee">Fee: $5</span>
                        </div>
                    </div>
                </section>

                <section className="how-to-use">
                    <h3 className="section-title">How to Use This System</h3>
                    <div className="steps-container">
                        <div className="step">
                            <div className="step-number">1</div>
                            <div className="step-content">
                                <h5>Create Your Profile</h5>
                                <p>Register with your national ID and personal information</p>
                            </div>
                        </div>
                        
                        <div className="step">
                            <div className="step-number">2</div>
                            <div className="step-content">
                                <h5>Choose Your Service</h5>
                                <p>Select from our range of license services</p>
                            </div>
                        </div>
                    </div>
                </section>

                <section className="system-info">
                    <div className="info-card">
                        <h4>System Features</h4>
                        <ul>
                            <li>✓ Real-time application tracking</li>
                            <li>✓ Secure digital document storage</li>
                            <li>✓ Automated test scheduling</li>
                        </ul>
                    </div>
                </section>
            </main>

            <footer className="home-footer">
                <p className="footer-note">
                    <strong>Note:</strong> This is the official DVLD digital platform. 
                    All services are processed according to national regulations.
                </p>
            </footer>
        </div>
    );
}

export default Home;
