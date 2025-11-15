import { Routes, Route, Navigate } from "react-router-dom";
import Login from "./pages/login/Login";
import Layout from "./Layout";
import Home from "./pages/home/Home";
import Users from "./pages/user/Users";
import Settings from "./pages/settings/Settings";
import People from "./pages/people/People";
import ErrorPage from "./pages/errorPage/ErrorPage";

function App() {
  const isLoggedIn = localStorage.getItem("loggedIn") === "true";

  return (
    <Routes>

      <Route path="/login" element={<Login />} />
      <Route path="/" element={<Navigate to={isLoggedIn ? "/layout/home" : "/login"} />} />

      {isLoggedIn ? (
        <Route path="/layout" element={<Layout />}>
          <Route index element={<Navigate to="home" />} />
          <Route path="home" element={<Home />} />
          <Route path="people" element={<People />} />
          <Route path="users" element={<Users />} />
          <Route path="settings" element={<Settings />} />
        </Route>
      ) : (
        <Route path="*" element={<Navigate to="/login" />} />
      )}
      
      <Route path="*" element={<ErrorPage />} />
    </Routes>
  );
}

export default App;