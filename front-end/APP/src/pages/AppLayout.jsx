import Navigation from "../components/Navigation.jsx";
import styles from "./AppLayout.module.css";
import Footer from "../components/Footer.jsx";

function AppLayout() {
  return (
    <div className={styles["app-component"]}>
      <Navigation />
      <h2>App page</h2>
      <Footer />
    </div>
  );
}

export default AppLayout;
