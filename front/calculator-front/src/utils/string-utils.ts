import { OperationTypes } from "../сalculator/consts/operation-types";

export const checkCalculatingExpression = (
  expression: string
) => {
  let x = /^[\d()+\-*\/\s]+$/;
  console.log(x.test(expression));
  console.log(expression);
  return true;
};
