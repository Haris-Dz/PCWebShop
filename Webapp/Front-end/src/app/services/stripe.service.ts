// src/app/services/stripe.service.ts
import { Injectable } from '@angular/core';
import { loadStripe } from '@stripe/stripe-js';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class StripeService {
  private stripePromise = loadStripe(environment.stripePublicKey);

  async redirectToCheckout(sessionId: string): Promise<void> {
    const stripe = await this.stripePromise;
    const { error } = await stripe!.redirectToCheckout({ sessionId });

    if (error) {
      console.error('Error redirecting to Stripe Checkout:', error);
    }
  }
}
