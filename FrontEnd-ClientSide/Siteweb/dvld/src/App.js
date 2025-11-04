import { BrowserRouter, Routes, Route, Navigate } from "react-router-dom";
//import './App.css';
import Login from "./pages/login/Login";
import Layout from "./Layout";
import Home from "./pages/home/Home";
import Users from "./pages/user/Users";
import Settings from "./pages/settings/Settings";
import People from "./pages/people/People";

function App() {
  const isLoggedIn = localStorage.getItem("loggedIn") === "true";

  return (
     <BrowserRouter>
      <Routes>
        <Route path="/" element={<Login />} />

        {isLoggedIn ? (
          <Route path="/Layout" element={<Layout />} >
            <Route index element={<Home />} />
            <Route path="home" element={<Home />} />
            <Route path="people" element={<People />} />
            <Route path="users" element={<Users />} />
            <Route path="settings" element={<Settings />} />
          </Route>
        ) : (
          <Route path="*" element={<Navigate to="/login" />} />
        )}
       <Route path="*" element={ "page not founde the not found page will be added late "} />
      </Routes>
    </BrowserRouter>


    // <BrowserRouter>
    //   <Routes>
    //     <Route path="/login" element={<Login />} />
        
    //     {isLoggedIn ? (
    //       <Route path="/" element={<Layout />}>
    //         <Route index element={<Home />} />
    //         <Route path="home" element={<Home />} />
    //         <Route path="users" element={<Users />} />
    //         <Route path="settings" element={<Settings />} />
    //       </Route>
    //     ) : (
    //       <Route path="*" element={<Navigate to="/login" replace />} />
    //     )}
        
    //     {/* Redirect root to login if not authenticated */}
    //     <Route path="/" element={<Navigate to={isLoggedIn ? "/home" : "/login"} replace />} />
    //   </Routes>
    // </BrowserRouter>
  );
}

export default App;