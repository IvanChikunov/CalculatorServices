import { useState } from "react";
import CalculationButton from "./components/calculation-button";
import { ButtonTypes } from "./consts/button-types";
import axios from "axios";
import styles from "./styles.module.scss";
import EditableInput from "./components/editable-input";
import { checkCalculatingExpression } from "../utils/string-utils";
import { CalculationServicesTypes } from "./consts/calculation-services-types";
import ServiceChooser from "./components/service-chooser";
import { server } from "./consts/api-consts";

const Calculator = () => {
  const [expression, setExpression] = useState<string>("");
  const [calculationResult, setCalculationResult] = useState<number | string>();
  const [choosedCalculator, setChoosedCalculator] = useState<number>(0);

  const addSymbol = (symbol: string) => {
    setExpression(expression + symbol);
  };

  const deleteLastSymbol = () => {
    setExpression(expression.slice(0, -1));
  };

  const calculate = () => {
    if (checkCalculatingExpression(expression))
      axios
        .get(
          `${server}api/Calculation?expression=${encodeURIComponent(
            expression
          )}&type=${choosedCalculator}`
        )
        .then((result) => setCalculationResult(result.data));
    else {
      setCalculationResult("Неверное выражение");
    }
  };

  return (
    <div>
      <EditableInput
        onChange={setExpression}
        expression={expression}
        result={calculationResult}
      />
      <div className={styles.calculatorService}>
        <div className={styles.calculatorGrid}>
          <CalculationButton
            onClick={() => addSymbol("(")}
            buttonType={ButtonTypes.secondary}
            value="("
          />
          <CalculationButton
            onClick={() => addSymbol(")")}
            buttonType={ButtonTypes.secondary}
            value=")"
          />
          <CalculationButton
            onClick={() => setExpression("")}
            buttonType={ButtonTypes.secondary}
            value="C"
          />
          <CalculationButton
            onClick={() => deleteLastSymbol()}
            buttonType={ButtonTypes.secondary}
            value="CE"
          />
          <CalculationButton onClick={() => addSymbol("7")} value="7" />
          <CalculationButton onClick={() => addSymbol("8")} value="8" />
          <CalculationButton onClick={() => addSymbol("9")} value="9" />
          <CalculationButton
            onClick={() => addSymbol("/")}
            buttonType={ButtonTypes.secondary}
            value="/"
          />
          <CalculationButton onClick={() => addSymbol("4")} value="4" />
          <CalculationButton onClick={() => addSymbol("5")} value="5" />
          <CalculationButton onClick={() => addSymbol("6")} value="6" />
          <CalculationButton
            onClick={() => addSymbol("*")}
            buttonType={ButtonTypes.secondary}
            value="*"
          />
          <CalculationButton onClick={() => addSymbol("1")} value="1" />
          <CalculationButton onClick={() => addSymbol("2")} value="2" />
          <CalculationButton onClick={() => addSymbol("3")} value="3" />
          <CalculationButton
            onClick={() => addSymbol("-")}
            buttonType={ButtonTypes.secondary}
            value="-"
          />
          <CalculationButton onClick={() => addSymbol("0")} value="0" />
          <CalculationButton onClick={() => addSymbol(".")} value="." />
          <CalculationButton
            onClick={calculate}
            buttonType={ButtonTypes.primary}
            value="="
          />
          <CalculationButton
            onClick={() => addSymbol("+")}
            buttonType={ButtonTypes.secondary}
            value="+"
          />
        </div>
        <ServiceChooser
          choosedService={choosedCalculator}
          setCalculatingService={setChoosedCalculator}
        />
      </div>
    </div>
  );
};

export default Calculator;
