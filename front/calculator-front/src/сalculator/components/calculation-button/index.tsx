import { Button } from "react-bootstrap";
import { ButtonTypes } from "../../consts/button-types";
import styles from "./styles.module.scss";

interface CalculationButtonProps {
  value: string;
  onClick?: () => void;
  buttonType?: ButtonTypes;
}

const CalculationButton = (props: CalculationButtonProps) => {
  return (
    <Button
      className={
        styles.calculationButton + " " + styles[props.buttonType || ""]
      }
      onClick={props.onClick}
    >
      {props.value}
    </Button>
  );
};

export default CalculationButton;
