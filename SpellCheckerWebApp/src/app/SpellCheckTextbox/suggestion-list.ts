import { Component, Input, Output, EventEmitter, OnInit } from '@angular/core'
import { SpellCheckService } from './Services/spellcheck-service';
@Component({
  selector: 'suggestion-list',
  templateUrl: './suggestion-list.html',
  styles: [`
    a {margin-left:10px}
  `]
})
export class SuggestionListComponent implements OnInit {
  @Input() word: any
  @Output() eventClick = new EventEmitter()
  suggestedWords: any[]

  constructor(private spellCheckService: SpellCheckService) {
    
  }

  ngOnInit() {
    this.spellCheckService.getSuggestions(this.word).subscribe(suggestedWords => this.suggestedWords = suggestedWords)
  }
  
  handleClickMe(selectedWord) {
    this.eventClick.emit(selectedWord);
  }
}
