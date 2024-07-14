import { Form } from "react-bootstrap";

import styles from "./styles.module.scss";

interface EditableInputProps {
  expression: string;
  result?: number | string;
  onChange: (value: string) => void;
}

const EditableInput = (props: EditableInputProps) => {
  return (
    <div className={styles.editableInput}>
      <Form.Control onChange={(val) => props.onChange(val.target.value)} placeholder="Введите формулу" value={props.expression} />
      <Form.Control disabled={true} value={props.result} />
    </div>
  );
};

export default EditableInput;
