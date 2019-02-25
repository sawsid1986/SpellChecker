import { Component } from '@angular/core'
import { SpellCheckService } from './Services/spellcheck-service';
@Component({
  selector: "spellcheck-textbox",
  templateUrl: './spellcheck-textbox.html',
  styles: [`
      .has-error {border-color: #dc3545;}
    `]
})
export class SpellCheckTextboxComponent {
  constructor(private spellCheckService: SpellCheckService) {

  }
  text = ''
  isValid = true

  handleEventClicked(data) {
    this.text = data
    this.isValid = true
  }

  onEnter(value) {
    if (value != '') {
      this.text = value
      this.spellCheckService.isCorrect(value).subscribe(isValid => { this.isValid=isValid })
    } else {
      this.isValid = true
    }
  }
}
