import { Button } from "react-bootstrap";
import { CalculationServicesTypes } from "../../consts/calculation-services-types";

import styles from "./styles.module.scss";

interface ServiceChooserProps {
  choosedService: number;
  setCalculatingService: (value: number) => void;
}

const ServiceChooser = (props: ServiceChooserProps) => {
  return (
    <div className={styles.servicesSwitcherGroup}>
      {Object.values(CalculationServicesTypes).map((k, index) => (
        <Button
          key={k}
          className={
            styles.buttonSwitcher +
            " " +
            (props.choosedService == index ? styles.selected : "")
          }
          onClick={() => props.setCalculatingService(index)}
        >
          {k}
        </Button>
      ))}
    </div>
  );
};

export default ServiceChooser;
