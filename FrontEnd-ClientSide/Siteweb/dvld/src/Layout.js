import Sidebar from "./component/sideBar/SideBar";
import Topbar from "./component/topBar/Topbar";
import { Outlet } from "react-router-dom";

function Layout() {
  return (
    <div style={{ display: "flex" }}>
      <Sidebar />
      <div style={{ flex: 1 }}>
        <Topbar />
        <div style={{ padding: "20px" }}>
          <Outlet />
        </div>
      </div>
    </div>
  );
}

export default Layout;
