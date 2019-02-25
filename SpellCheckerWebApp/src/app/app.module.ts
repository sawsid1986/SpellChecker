import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http'

import { AppComponent } from './app.component';
import { SpellCheckTextboxComponent } from './SpellCheckTextbox/spellcheck-textbox';
import { SuggestionListComponent } from './SpellCheckTextbox/suggestion-list';
import { SpellCheckService } from './SpellCheckTextbox/Services/spellcheck-service';

@NgModule({
  declarations: [
    AppComponent,
    SpellCheckTextboxComponent,
    SuggestionListComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule
  ],
  providers: [SpellCheckService],
  bootstrap: [AppComponent]
})
export class AppModule { }
