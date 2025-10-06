import { AbstractControl, ValidationErrors, ValidatorFn } from "@angular/forms";

export function formValid(): ValidatorFn {
  return (control: AbstractControl): ValidationErrors | null => {
    const nom = control.get("nom");
    const comment = control.get("comment")
    // On regarde si le champ est rempli avant de faire la validation
    // On fait notre validation. Includes retourne un booléen.
    const estValide = !comment?.value.includes(nom?.value);

    // On retourne null si c'est valide, ou un objet décrivant l'erreur sinon
    return estValide ? null : { formValid: true };
  };
}