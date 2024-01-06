import styles from "./MonthlySalary.module.css";

import BoardHeader from "./BoardHeader.jsx";
import MonthlySalaryDocument from "./MonthlySalaryDocument.jsx";
import LoaderWheel from "../LoaderWheel.jsx";
import { useState } from "react";

function MonthlySalary() {
  const [loading, setLoading] = useState(false);

  return (
    <>
      <h2 className={styles.dashHeading}>Salary</h2>
      <section className={styles.board}>
        <BoardHeader />
        {loading && <LoaderWheel />}
        <div className={styles.salaryWrapper}>
          <MonthlySalaryDocument />
          {/* <div className={styles.wallet}>
            <ion-icon name="wallet-outline"></ion-icon>
            <p className={styles.walletText}>Get money</p>
          </div> */}
        </div>
      </section>
    </>
  );
}
export default MonthlySalary;

function Test() {
  return <div>tests</div>;
}
