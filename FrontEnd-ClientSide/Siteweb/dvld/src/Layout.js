// import Sidebar from "./component/sideBar/SideBar";
// import Topbar from "./component/topBar/Topbar";
// import { Outlet } from "react-router-dom";
// import "./Layout.css";

// function Layout() {
//   return (
//     <div className="layout-container">
//       <Sidebar />
//       <div className="layout-content">
//         <Topbar />
//         <main className="layout-outlet">
//           <Outlet />
//         </main>
//       </div>
//     </div>
//   );
// }

// export default Layout;
import Sidebar from "./component/sideBar/SideBar";
import Topbar from "./component/topBar/Topbar";
import { Outlet } from "react-router-dom";
import "./Layout.css";

function Layout() {
  return (
    <div className="layout-container">

      <Sidebar className="sidebar" />
      <Topbar className="topbar" />
      <main className="main-content">
        <Outlet />
      </main>
      
    </div>
  );
}

export default Layout;