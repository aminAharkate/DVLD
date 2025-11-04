
// import './Topbar.css'

// export default function Topbar() {
//   return (
//     <div style={{
//       background: "#12004b",
//       color: "#ff99ff",
//       padding: "10px 0",
//       position: "sticky",
//       top: 0,
//       zIndex: 10,
//       overflow: "hidden",
//       boxShadow: "0 0 20px rgba(255, 0, 255, 0.3)"
//     }}>
//       <div style={{
//         whiteSpace: "nowrap",
//         display: "inline-block",
//         animation: "scrollText 15s linear infinite",
//         fontSize: "18px",
//         paddingLeft: "100%",
//       }}>
//         Driving & Vehicle License Department System
//       </div>
//     </div>
//   );
// }

import './Topbar.css';

export default function Topbar() {
  return (
    <div className="topbar">
      <div className="scroll-text">
        Driving & Vehicle License Department System
      </div>
    </div>
  );
}


