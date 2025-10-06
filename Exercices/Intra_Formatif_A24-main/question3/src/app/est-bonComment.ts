import { AbstractControl, ValidationErrors, ValidatorFn } from "@angular/forms";

export function bonComment(): ValidatorFn {
  return (control: AbstractControl): ValidationErrors | null => {
    const comment: String = control.value;
    // On regarde si le champ est rempli avant de faire la validation
    // On fait notre validation. Includes retourne un booléen.
    var newcomment = comment.split(" ");
    const estValide = newcomment.length >= 10;

    // On retourne null si c'est valide, ou un objet décrivant l'erreur sinon
    return estValide ? null : { bonComment: true };
  };
}